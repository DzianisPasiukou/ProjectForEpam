myApp.service("fileUpload", function ($http) {

    this.getTraffic = function () {
        var url = "/api/FileUpload";
        return $http.get(url);
    }
    this.upload = function (file) {
        var url = "/api/FileUpload?file=" + file;
        return $http.post(url);
    }
});