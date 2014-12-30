myApp.service("noteInfoData", function ($http) {
    this.getNoteInfo = function (id) {
        var url = "/api/NoteInfo/" + id;
        return $http.get(url);
    }
    /*
    this.getCharacter = function (id) {
       var url = "/api/NoteInfo/" + id;
        return $http.get(url);
    }
    */
});