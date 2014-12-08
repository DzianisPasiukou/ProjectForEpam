myApp.service("catalogData", function ($http) {
    this.getTree = function () {
        var url = "/api/CatalogTree"
        return $http.get(url);
    }
})