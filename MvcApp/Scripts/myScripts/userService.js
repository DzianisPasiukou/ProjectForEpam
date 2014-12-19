myApp.service("userInfoData", function ($http) {
    this.getUserName = function (idUser) {
        var url = "/api/UsersInfo/" + idUser;
        return $http.get(url);
    }
});