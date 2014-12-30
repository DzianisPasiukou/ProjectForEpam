myApp.service("fileUpload", function ($http) {

    this.getTraffic = function () {
        var url = "/api/FileUpload";
        return $http.get(url);
    }
    this.upload = function (file) {
        var url = "/api/FileUpload";
        console.log(file);
        return $http.post(url, "file=" + file);
    }
});