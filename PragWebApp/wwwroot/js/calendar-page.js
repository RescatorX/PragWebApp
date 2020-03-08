////////////////////////////////////////////
/// CalendarCtrl ///////////////////////////
////////////////////////////////////////////

var app = angular.module('CalendarPage', ['ngMessages', 'mgcrea.ngStrap']);

app.controller('CalendarCtrl', function ($scope, $http, $timeout) {

    // global init data
    $scope.initData = {};
    $scope.initialized = false;
    $scope.eventMode = "";
    $scope.events = [];
    $scope.weekDayRecords = [];
    $scope.monthDayRecords = [];
    $scope.pixelsToMinute = 1;
    $scope.currentEvent = {};
    $scope.eventStart = null;
    $scope.eventEnd = null;
    $scope.ownerName = "";
    $scope.customerName = "";
    $scope.sendEmailText = "";
    $scope.sendSmsText = "";
    $scope.allDayText = "";

    // Selector grid
    $scope.currentYear = 0;
    $scope.currentMonth = 0;
    $scope.monthDays = 30;
    $scope.selectorRows = [];
    $scope.selectedDay = {};
    $scope.weekOfSelectedDay = { days: [] };
    $scope.monthOfSelectedDay = { days: [] };

    // init data
    $scope.initData = function () {

        try {

            $scope.initModel();

        } catch (error) {
            console.log("initData.error: " + error);
        }
    };

    $scope.initModel = function () {

        var yearValue = $scope.currentYear;
        var monthValue = $scope.currentMonth;

        $http({ method: "POST", url: "/api/events/initData", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ year: yearValue, month: monthValue }) }).then(
            function successCallback(response) {

                $scope.initData = response.data;
                $scope.currentYear = $scope.initData.year;
                $scope.currentMonth = $scope.initData.month;
                $scope.monthDays = $scope.initData.monthDays;
                $scope.selectorRows = $scope.initData.weeks;
                $scope.selectedDay = null;
                for (var i = 0; i < $scope.selectorRows.length; i++) {
                    var week = $scope.selectorRows[i];
                    var found = false;
                    for (var j = 0; j < week.days.length; j++) {

                        if (week.days[j].isSelected == true) {
                            $scope.selectedDay = week.days[j];
                            found = true;
                            break;
                        }
                    }

                    if (found) {
                        break;
                    }
                }

                $scope.selectDay($scope.selectedDay);

                $scope.initialized = true;

                $("#calendar-user-row").css("display", "block");
                $("#calendar-data-row").css("display", "flex");
            },
            function errorCallback(response) {
                console.log("initModel error: " + JSON.stringify(response));
            }
        );
    };

    $scope.prevMonth = function () {

        if ($scope.currentMonth > 1) {
            $scope.currentMonth -= 1;
        } else {
            $scope.currentYear -= 1;
            $scope.currentMonth = 12;
        }
        $scope.initModel();
    };

    $scope.nextMonth = function () {

        if ($scope.currentMonth < 12) {
            $scope.currentMonth += 1;
        } else {
            $scope.currentYear += 1;
            $scope.currentMonth = 1;
        }
        $scope.initModel();
    };

    $scope.selectDay = function (day) {

        $scope.deselectDays();
        day.isSelected = true;
        $scope.selectedDay = day;

        $scope.getWeekOfSelectedDay();
        $scope.getMonthOfSelectedDay();

        $scope.eventStart = new Date($scope.selectedDay.year, $scope.selectedDay.month - 1, $scope.selectedDay.day, 6, 0, 0);
        $scope.eventEnd = new Date($scope.selectedDay.year, $scope.selectedDay.month - 1, $scope.selectedDay.day, 7, 0, 0);

        $scope.getEvents();
    };

    $scope.deselectDays = function () {

        angular.forEach($scope.selectorRows, function (row) {
            angular.forEach(row.days, function (day) {
                day.isSelected = false;
            });
        });
    };

    $scope.addEvent = function (day, halfHour, stylist) {

        $scope.currentEvent = { allDay: false, owner: stylist };

        $scope.ownerName = stylist.name;
        $scope.sendEmailText = "";
        $scope.sendSmsText = "";
        $scope.allDayText = "";

        if (day != null) {

            var hours = 7;
            var minutes = 0;
            if (halfHour != null) {
                let halfHours = (halfHour % 2);
                minutes += 30 * halfHours;
                hours += ((halfHour - halfHours) / 2);
            }

            $scope.eventStart = new Date(day.year, day.month - 1, day.day, hours, minutes, 0);
            $scope.eventEnd = new Date(day.year, day.month - 1, day.day, hours + 1, minutes, 0);
        } else {
            $scope.eventStart = new Date($scope.selectedDay.year, $scope.selectedDay.month - 1, $scope.selectedDay.day, 7, 0, 0);
            $scope.eventEnd = new Date($scope.selectedDay.year, $scope.selectedDay.month - 1, $scope.selectedDay.day, 8, 0, 0);
        }

        $scope.eventMode = "C";
    };

    $scope.hideEvent = function () {

        $scope.currentEvent = null;
        $scope.eventMode = "";
    };

    $scope.cancelEvent = function () {

        if ($scope.currentEvent != null) {
            $scope.eventMode = "S";
        } else {
            $scope.eventMode = "";
        }
    };

    $scope.saveEvent = function () {

        // send to server
        $scope.eventMode = "S";
    };

    $scope.editEvent = function () {

        // send to server
        $scope.eventMode = "E";
    };

    $scope.range = function (min, max, step) {
        step = step || 1;
        var input = [];
        for (var i = min; i <= max; i += step) input.push(i);
        return input;
    };

    $scope.getWeekOfSelectedDay = function () {
        angular.forEach($scope.initData.weeks, function (week) {
            angular.forEach(week.days, function (day) {
                if (day.isSelected == true) {
                    $scope.weekOfSelectedDay = week;
                }
            });
        });
    };

    $scope.getMonthOfSelectedDay = function () {
        $scope.monthOfSelectedDay = { days: [] };
        angular.forEach($scope.initData.weeks, function (week) {
            angular.forEach(week.days, function (day) {
                if (day.isInMonth == true) {
                    $scope.monthOfSelectedDay.days.push(day);
                }
            });
        });
    };

    $scope.getCustomerName = function (event) {
        var customerName = "";
        if (event.customer != null) {
            customerName = event.customer.firstName + " - " + event.customer.lastName;
        } else {
            customerName = event.customerName;
        }
        return customerName;
    };

    $scope.dayEventFilter = function (event) {
        var valid = ((("" + event.start).indexOf(("" + $scope.selectedDay.year) + "-" + ( "" + $scope.selectedDay.month) + "-" + ( "" + $scope.selectedDay.day)) >= 0) ||
                     (("" + event.start).indexOf(("" + $scope.selectedDay.year) + "-" + ("0" + $scope.selectedDay.month) + "-" + ( "" + $scope.selectedDay.day)) >= 0) ||
                     (("" + event.start).indexOf(("" + $scope.selectedDay.year) + "-" + ( "" + $scope.selectedDay.month) + "-" + ("0" + $scope.selectedDay.day)) >= 0) ||
                     (("" + event.start).indexOf(("" + $scope.selectedDay.year) + "-" + ("0" + $scope.selectedDay.month) + "-" + ("0" + $scope.selectedDay.day)) >= 0));

        return valid;
    };

    $scope.weekEventFilter = function (event) {
        $scope.getWeekOfSelectedDay();
        var eventStartDate = new Date(("" + event.start));
        var weekFirstDate = new Date(("" + $scope.weekOfSelectedDay.days[0].date));
        var weekLastDate = new Date(("" + $scope.weekOfSelectedDay.days[6].date));
        return ((eventStartDate >= weekFirstDate) && (eventStartDate <= weekLastDate));
    };

    $scope.getEvents = function () {

        var yearValue = $scope.currentYear;
        var monthValue = $scope.currentMonth;

        $http({ method: "POST", url: "/api/events/getEvents", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ year: yearValue, month: monthValue }) }).then(
            function successCallback(response) {

                $scope.events = response.data;
                $scope.weekDayRecords = [];

                $scope.weekDayRecords = [];
                angular.forEach($scope.weekOfSelectedDay.days, function (weekDay) {
                    var weekDayEvents = [];
                    angular.forEach($scope.events, function (event) {
                        if ($scope.isEventInDay(event, weekDay)) {
                            weekDayEvents.push(event);
                        }
                    });
                    $scope.weekDayRecords.push({ day: weekDay, dayEvents: weekDayEvents });
                });

                $scope.monthDayRecords = [];
                angular.forEach($scope.monthOfSelectedDay.days, function (monthDay) {
                    var monthDayEvents = [];
                    angular.forEach($scope.events, function (event) {
                        if ($scope.isEventInDay(event, monthDay)) {
                            monthDayEvents.push(event);
                        }
                    });
                    $scope.monthDayRecords.push({ day: monthDay, dayEvents: monthDayEvents });
                });

                var len = $scope.weekDayRecords.length;
            },
            function errorCallback(response) {
                console.log("getEvents error: " + JSON.stringify(response));
            }
        );
    };

    $scope.saveEvent = function () {

        $scope.currentEvent.start = new Date($scope.eventStart.getTime() - ($scope.eventStart.getTimezoneOffset() * 60000)).toISOString();
        $scope.currentEvent.end = new Date($scope.eventEnd.getTime() - ($scope.eventEnd.getTimezoneOffset() * 60000)).toISOString();
        var savingCalendarEvent = angular.toJson($scope.currentEvent);

        $.ajax({
            type: "POST",
            url: "/api/events/saveEvent",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: savingCalendarEvent,
            error: function (xhr) {
                console.log("saveEvent error: " + JSON.stringify(xhr));
            },
            success: function (data) {
                $scope.currentEvent = null;
                $scope.eventMode = '';
                $scope.getEvents();
            }
        });
    };

    $scope.deleteEvent = function () {

        var deletingCalendarEvent = angular.toJson($scope.currentEvent);

        $.ajax({
            type: "POST",
            url: "/api/events/deleteEvent",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: deletingCalendarEvent,
            error: function (xhr) {
                console.log("deleteEvent error: " + JSON.stringify(xhr));
            },
            success: function (data) {
                $scope.currentEvent = null;
                $scope.eventMode == '';
                $scope.getEvents();
            }
        });
    };

    $scope.getTopMinutes = function (event) {

        if (event != null) {
            var timePart = ("" + event.start).substring(11);
            var hours = parseInt(timePart.substring(0, 2));
            var minutes = parseInt(timePart.substring(3, 5));
            return (((hours - 7) * 60) + minutes);
        } else {
            return 0;
        }
    };

    $scope.getHeightMinutes = function (event) {

        if (event != null) {
            var topMinutes = $scope.getTopMinutes(event);
            var timePart = ("" + event.end).substring(11);
            var hours = parseInt(timePart.substring(0, 2));
            var minutes = parseInt(timePart.substring(3, 5));
            return (((hours - 7) * 60) + minutes - topMinutes);
        } else {
            return 0;
        }
    };

    $scope.showEventDetail = function (event) {

        $scope.currentEvent = event;

        $scope.eventStart = new Date($scope.currentEvent.start);
        $scope.eventEnd = new Date($scope.currentEvent.end);

        $scope.ownerName = $scope.currentEvent.owner.firstName + " " + $scope.currentEvent.owner.lastName;
        if ($scope.currentEvent.customer != null) {
            $scope.customerName = $scope.currentEvent.customer.firstName + " " + $scope.currentEvent.customer.lastName;
        }
        $scope.sendEmailText = (($scope.currentEvent.sendEmail == true) ? "ano" : "ne");
        $scope.sendSmsText = (($scope.currentEvent.sendSms == true) ? "ano" : "ne");
        $scope.allDayText = (($scope.currentEvent.allDay == true) ? "ano" : "ne");

        $scope.eventMode = 'S';
    };

    $scope.isEventInDay = function (event, day) {

        var d1 = new Date(event.start);

        return ((d1.getDate() == day.day) && ((d1.getMonth() + 1) == day.month) && (d1.getFullYear() == day.year));
    }

    $scope.addAllDayEvent = function () {
    };

    $scope.addAllWeekEvent = function () {
    };

    $scope.addAllMonthEvent = function () {
    };

    $scope.addEventFromDay = function (halfHour, stylist) {
        $scope.addEvent($scope.selectedDay, halfHour - 1, stylist);
    };

    $scope.customerChanged = function () {
        $scope.currentEvent.customerName = $scope.currentEvent.customer.firstName + " " + $scope.currentEvent.customer.lastName;
        $scope.currentEvent.customerEmail = $scope.currentEvent.customer.email;
        $scope.currentEvent.customerPhoneNumber = $scope.currentEvent.customer.phoneNumber;
        $scope.currentEvent.sendEmail = $scope.currentEvent.customer.sendEmails;
        $scope.currentEvent.sendSms = $scope.currentEvent.customer.sendSmss;
        $scope.currentEvent.note = $scope.currentEvent.customer.description;
    };

    $scope.getStylistIndex = function (event) {
        var result = 0;
        var index = 0;
        angular.forEach($scope.initData.stylists, function (stylist) {
            if (stylist.id == event.owner.id) {
                result = index;
            }
            index++;
        });
        return result;
    };

    $scope.initData();

}); // CalendarCtrl

app.directive('modal', function () {
    return {
        template: '<div class="modal">' +
            '<div class="modal-dialog">' +
            '<div class="modal-content">' +
            '<div class="modal-header">' +
            '<h4 class="modal-title">{{ title }}</h4>' +
            '</div>' +
            '<div class="modal-body" ng-transclude></div>' +
            '</div>' +
            '</div>' +
            '</div>',
        restrict: 'E',
        transclude: true,
        replace: true,
        scope: true,
        link: function postLink(scope, element, attrs) {
            scope.title = attrs.title;

            scope.$watch(attrs.visible, function (value) {
                if (value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });
        }
    };
});

app.directive('timePicker', function () {
    return {
        restrict: 'E',
        require: ['ngModel'],
        scope: {
            ngModel: '='
        },
        replace: true,
        template:
            '<div class="input-group bootstrap-timepicker">' +
            '<input type="text"  class="form-control" ngModel>' +
            '<span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i>' +
            '</div>',
        link: function (scope, element, attrs) {
            var input = element.find('input');
            input.timepicker('showWidget');
            element.bind('blur keyup change', function () {
                scope.ngModel = input.val()
            });
        }
    }
});
