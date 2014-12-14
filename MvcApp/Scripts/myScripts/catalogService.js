﻿myApp.service("catalogData", function ($http) {
    this.getTree = function () {
        var url = "/api/CatalogTree"
        return $http.get(url);
    }
    this.getRecord = function (id) {
        var url = "/api/CatalogTree/" + id
        return $http.get(url);
    }
    this.getUserName = function (idUser) {
        var url = "/api/UsersInfo/" + idUser;
        return $http.get(url);
    }
})