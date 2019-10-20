﻿////////////////////////////////////////////
/// CalendarCtrl ///////////////////////////
////////////////////////////////////////////

var app = angular.module('CalendarPage', ['ngMessages']);

app.controller('CalendarCtrl', function ($scope, $http, $timeout) {

    // global init data
    $scope.initData = {};
    $scope.interval = "M";
    $scope.eventMode = "A";
    $scope.events = [];
    $scope.pixelsToMinute = 1;
    $scope.currentEvent = {};

    // Selector grid
    $scope.currentYear = 0;
    $scope.currentMonth = 0;
    $scope.monthDays = 30;
    $scope.selectorRows = [];
    $scope.selectedDay = {};
    $scope.weekOfSelectedDay = { days: []};
    $scope.monthOfSelectedDay = { days: []};

    // init data
    $scope.initData = function () {

        try {

            //$scope.initEventStartDatePicker();
            //$scope.initEventEndDatePicker();
            //$scope.initEventCreatedDatePicker();
/*
            $('#eventStart').pickatime({
                // 12 or 24 hour
                twelvehour: false,
            });
*/
            $scope.initModel();

        } catch (error) {
            console.log("initData.error: " + error);
        }
    };

    $scope.initModel = function () {

        var yearValue = $scope.currentYear;
        var monthValue = $scope.currentMonth;
        var intervalValue = $scope.interval;

        $http({ method: "POST", url: "/api/events/initData", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ year: yearValue, month: monthValue, interval: intervalValue }) }).then(
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
                $scope.getWeekOfSelectedDay();
                $scope.getMonthOfSelectedDay();

                $scope.getEvents();
            },
            function errorCallback(response) {
                console.log("initModel error: " + JSON.stringify(response));
            }
        );
    };

    $scope.intervalDay = function () {
        $scope.interval = "D";
    }

    $scope.intervalWeek = function () {
        $scope.interval = "W";
    }

    $scope.intervalMonth = function () {
        $scope.interval = "M";
    }

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
        $scope.getEvents();
    };

    $scope.deselectDays = function () {
        angular.forEach($scope.selectorRows, function (row) {
            angular.forEach(row.days, function (day) {
                day.isSelected = false;
            });
        });
    };

    $scope.addEvent = function () {
        $scope.eventMode = "C";
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
        return ((("" + event.start).indexOf(("" + $scope.selectedDay.year) + "-" + ("" + $scope.selectedDay.month) + "-" + ("" + $scope.selectedDay.day)) >= 0) ||
                (("" + event.start).indexOf(("" + $scope.selectedDay.year) + "-" + ("0" + $scope.selectedDay.month) + "-" + ("" + $scope.selectedDay.day)) >= 0) ||
                (("" + event.start).indexOf(("" + $scope.selectedDay.year) + "-" + ("" + $scope.selectedDay.month) + "-" + ("0" + $scope.selectedDay.day)) >= 0));
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
        var intervalValue = $scope.interval;

        $http({ method: "POST", url: "/api/events/getEvents", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ year: yearValue, month: monthValue, interval: intervalValue }) }).then(
            function successCallback(response) {

                $scope.events = response.data;
            },
            function errorCallback(response) {
                console.log("getEvents error: " + JSON.stringify(response));
            }
        );
    };

    $scope.showEvent = function (event) {

        $scope.currentEvent = event;
        $('#eventStart').data("DateTimePicker").value($scope.currentEvent.start);
        $('#eventEnd').data("DateTimePicker").value($scope.currentEvent.end);
        //$('#eventCreated').data("DateTimePicker").value($scope.currentEvent.created);
    };

    $scope.getTopMinutes = function (event) {
        var timePart = ("" + event.start).substring(11);
        var hours = parseInt(timePart.substring(0, 2));
        var minutes = parseInt(timePart.substring(3, 5));
        return (((hours - 6) * 60) + minutes);
    };

    $scope.getHeightMinutes = function (event) {
        var topMinutes = $scope.getTopMinutes(event);
        var timePart = ("" + event.end).substring(11);
        var hours = parseInt(timePart.substring(0, 2));
        var minutes = parseInt(timePart.substring(3, 5));
        return (((hours - 6) * 60) + minutes - topMinutes);
    };

    $scope.initEventStartDatePicker = function () {
        $('#eventStart').dateTimePicker({
            locale: 'cz'
        });
    };

    $("#eventStart").on("dp.change", function (e) {
    });

    $scope.initEventEndDatePicker = function () {
        $('#eventEnd').dateTimePicker({
            locale: 'cz'
        });
    };

    $scope.initEventCreatedDatePicker = function () {
        $('#eventCreated').dateTimePicker({
            locale: 'cz'
        });
    };

    $scope.showEventDetail = function (event) {
        var name = event.title;
    };

    $scope.addAllDayEvent = function () {
    };

    $scope.addAllWeekEvent = function () {
    };

    $scope.addAllMonthEvent = function () {
    };

    $scope.addEventFromDay = function (halfHour) {
    };

    $scope.addEventFromWeek = function (day, halfHour) {
    };

    $scope.addEventFromMonth = function (day, halfHour) {
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

app.directive('dateTimePicker', function () {

    return {
        require: '?ngModel',
        restrict: 'AE',
        scope: {
            pick12HourFormat: '@',
            language: '@',
            useCurrent: '@',
            location: '@'
        },
        link: function (scope, elem, attrs) {
            elem.datetimepicker({
                pick12HourFormat: scope.pick12HourFormat,
                language: scope.language,
                useCurrent: scope.useCurrent
            })

            //Local event change
            elem.on('blur', function () {

                console.info('this', this);
                console.info('scope', scope);
                console.info('attrs', attrs);
            })
        }
    };
});
