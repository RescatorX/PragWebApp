////////////////////////////////////////////
/// CalendarCtrl ///////////////////////////
////////////////////////////////////////////

var app = angular.module('CalendarPage', ['ngMessages']);

app.controller('CalendarCtrl', function ($scope, $http, $timeout) {

    // global init data
    $scope.initData = {};
    $scope.interval = "M";
    $scope.eventMode = "A";

    // Selector grid
    $scope.currentYear = 0;
    $scope.currentMonth = 0;
    $scope.monthDays = 30;
    $scope.selectorRows = [];
    $scope.selectedDay = {};
    $scope.weekOfSelectedDay = {};

    // init data
    $scope.initData = function () {

        try {
            $scope.initModel();
        } catch (error) { }
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
            },
            function errorCallback(response) {
                console.log("generateSelectorRows error: " + JSON.stringify(response));
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
    }

    $scope.addAllDayEvent = function () {
    };

    $scope.addAllWeekEvent = function () {
    };

    $scope.addAllMonthEvent = function () {
    };

    $scope.addEventFromDay = function (halfHour) {
    };

    $scope.addEventFromWeek = function (dayIndex, halfHour) {
    };

    $scope.addEventFromMonth = function (monthIndex, halfHour) {
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
