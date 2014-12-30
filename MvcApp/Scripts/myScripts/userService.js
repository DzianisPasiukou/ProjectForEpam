myApp.service("userInfoData", function ($http) {
    this.getUserName = function (idUser) {
        var url = "/api/UsersInfo/" + idUser;
        return $http.get(url);
    }
    this.getLikeEnable = function (id, noteOrFile) {
        var url = "/api/UsersInfo?id=" + id + "&noteOrFile=" + noteOrFile;
        return $http.get(url);
    }
    this.putLike = function myfunction(noteOrFile, idNote) {
        var url = "/api/UsersInfo?noteOrFile=" + noteOrFile + "&id=" + idNote;
        return $http.put(url);
    }
});