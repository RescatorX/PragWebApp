////////////////////////////////////////////
/// CalendarCtrl ///////////////////////////
////////////////////////////////////////////

var app = angular.module('CalendarPage', ['ngMessages']);

app.controller('CalendarCtrl', function ($scope, $http, $timeout) {

    // global init data
    $scope.initData = {};

    // Selector grid
    $scope.currentYear = 0;
    $scope.currentMonth = 0;
    $scope.selectorRows = [];
    $scope.selectedDay = {};

    // init data
    $scope.initData = function () {

        try {
            $scope.generateSelectorRows();
        } catch (error) { }
    };

    $scope.generateSelectorRows = function () {

        var yearValue = $scope.currentYear;
        var monthValue = $scope.currentMonth;

        $http({ method: "POST", url: "/api/events/initData", dataType: "json", headers: { "Content-Type": "application/json" }, data: JSON.stringify({ year: yearValue, month: monthValue }) }).then(
            function successCallback(response) {

                $scope.initData = response.data;
                $scope.currentYear = $scope.initData.year;
                $scope.currentMonth = $scope.initData.month;
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
            },
            function errorCallback(response) {
                console.log("generateSelectorRows error: " + JSON.stringify(response));
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
        $scope.generateSelectorRows();
    };

    $scope.nextMonth = function () {
        if ($scope.currentMonth < 12) {
            $scope.currentMonth += 1;
        } else {
            $scope.currentYear += 1;
            $scope.currentMonth = 1;
        }
        $scope.generateSelectorRows();
    };

    $scope.selectDay = function (day) {
        this.deselectDays();
        day.isSelected = true;
        this.selectedDay = day;
    };

    $scope.deselectDays = function () {
        angular.forEach($scope.selectorRows, function (row) {
            angular.forEach(row.days, function (day) {
                day.isSelected = false;
            });
        });
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
