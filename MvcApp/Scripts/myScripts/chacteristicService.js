myApp.service("chacteristicService", function ($http) {
    this.getCharacteristic = function () {
        var url = "/api/CharacteristicInfo"
        return $http.get(url);
    }
    this.getCharacteristicById = function (idNote) {
        var url = "/api/CharacteristicInfo/" + idNote;
        return $http.get(url);
    }
    this.putCharacteristic = function (name, value, idNote) {
        var url = "/api/CharacteristicInfo?name=" + name + "&value=" + value + "&IdNote=" + idNote;
        return $http.put(url);
    }
});