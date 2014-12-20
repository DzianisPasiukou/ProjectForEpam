var app = angular.module('Chat', ['ngGrid']);
app.controller('MyCtrl', function ($scope, $http) {
    $scope.myData = [{ Id: 1, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 2, User: "Tiancum", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 3, User: "Jacob", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 4, User: "Nephi", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 5, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 6, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 7, User: "Nephi", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 8, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 9, User: "Moroni", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" },
                     { Id: 10, User: "Enos", Date: "16.12.2014 22:01", Message: "Hello", Link: "~/Account/Chat" }];


});


function lol(id) {
    alert(id);
    console.log(id);
};

$('#minimize').click(function () {
    alert('lol');
});