﻿myApp.controller('taskCtrl', function ($scope) {
    
    $scope.prevClick = function () {
        if ($scope.currentPage == 0) {
            return;
        }
        else {
            $scope.currentPage -= 1;
        }
    }

    $scope.nextClick = function () {
        if ($scope.currentPage > ($scope.tasks.length / $scope.pageSize) - 1) {
            return;
        }
        else {
            $scope.currentPage += 1;
        }
    }

    $scope.taskAdapter = "No Change";
    $scope.changeAdapter = function (adapter) {
        $scope.taskAdapter = adapter;
    };

    $scope.time = "No Change";
    $scope.times = [];
    for (var i = 0; i < 24; i++) {
        $scope.times[i] = i.toString() + ":00";
    }
    $scope.changeTime = function (time) {
        $scope.time = time;
    };

    $scope.AddTask = function () {
        dateNeedFormat = new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();
        $.ajax({
            url: '/api/Task/?selectWeekDay=' + $scope.selectWeekDay + "&WhoChange=" + $('#userLogin').text() + "&DateChange=" + dateNeedFormat + "&TimeStart=" + $scope.time + "&nameTask=" + $('#nameTask').val() + "&adapter=" + $scope.taskAdapter,
            type: "POST",
            success: function () {
                var data = { Adapter: $scope.taskAdapter, DateChange: dateNeedFormat, DateWeekStart: $scope.selectWeekDay, IsEnable: true, Name: $('#nameTask').val(), TimeStart: $scope.time, WhoChange: $('#userLogin').text() };
                $scope.tasks.push(data);
                $scope.$apply();
            }
        });
    };



    $scope.checkClick = function (task, isEnable) {
        dateNeedFormat = new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();
        $.ajax({
            url: '/api/Task/?task=' + task + "&isEnable=" + isEnable + "&WhoChange=" + $('#userLogin').text() + "&DateChange=" + dateNeedFormat,
            type: "PUT",
        });
        for (var i = 0; i < $scope.tasks.length; i++) {
            if ($scope.tasks[i].Name == task)
            {
                $scope.tasks[i].DateChange = dateNeedFormat;
                $scope.tasks[i].WhoChange = $('#userLogin').text();
            }
        }
    };

    $.ajax({
        url: '/api/Task',
        type: "GET",
        success: function (data) {
            $scope.tasks = data.Tasks;
            $scope.adapters = data.Adapters;

            $scope.currentPage = 0;
            $scope.pageSize = 10;
            $scope.numberOfPages = function () {
                return Math.ceil($scope.tasks.length / $scope.pageSize);
            }

            $scope.$apply();
        }
    });

    $scope.selectWeekDay = "No Change";
    $(document).ready(function () {
        $('.weekday').click(function () {
            if (this.checked) {
                $('.weekday').attr('checked', false);
                this.checked = true;
                $scope.selectWeekDay = $(this).parent().text();    
            };
        });
    });

});

