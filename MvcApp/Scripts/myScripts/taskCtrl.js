myApp.controller('taskCtrl', function ($scope) {
    $.ajax({
        url: '/api/Task',
        success: function (data) {
            console.log(data);

           
        }
    });
});

