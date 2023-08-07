function getLocation() {
    return new Promise(function (resolve, reject) {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var GetCurrentLocationResultModel = {
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                };
                resolve(GetCurrentLocationResultModel);
            });
        } else {
            reject("Geolocation API desteklenmiyor.");
        }
    });
}
