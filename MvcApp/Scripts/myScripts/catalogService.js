myApp.service("catalogData", function ($http) {
    this.getUsers = function () {
        var url = "api/catalogs"
        return $http.get(url);
    }
})