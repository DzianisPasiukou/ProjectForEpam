myApp.service("usersData", function ($http) {
    this.getUsers = function () {
        var url = "api/users"
        return $http.get(url);
    }
})