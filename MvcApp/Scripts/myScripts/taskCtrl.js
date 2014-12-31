myApp.controller('taskCtrl', function ($scope) {
    
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

    $scope.checkClick = function (task, isEnable) {
        $.ajax({
            url: '/api/Task/?task=' + task + "&isEnable=" + isEnable + "&WhoChange=" + $('#userLogin').text(),
            type: "PUT",
        });
        for (var i = 0; i < $scope.tasks.length; i++) {
            if ($scope.tasks[i].Name == task)
            {
                dateNeedFormat = new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();
                $scope.tasks[i].DateChange = dateNeedFormat;

                $scope.tasks[i].WhoChange = $('#userLogin').text();
            }
        }
    };
    
    $.ajax({
        url: '/api/Task',
        type: "GET",
        success: function (data) {
            $scope.tasks = data;

            $scope.currentPage = 0;
            $scope.pageSize = 10;
            $scope.numberOfPages = function () {
                return Math.ceil($scope.tasks.length / $scope.pageSize);
            }

            $scope.$apply();
        }
    });

});