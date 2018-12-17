const flightModel = function () {
    let flightUrl = `appdata/${storage.appKey}/flights`
    const add = function (params) {
        let data = {
            "destination":params.destination,
            "origin":params.origin,
            "departure":params.departureDate,
            "departureTime":params.departureTime,
            "seats":params.seats,
            "cost":params.cost,
            "image":params.img,
            "isPublic": !!params.public
        };
        return requester.post(flightUrl, data);
    };

    const flights = function (onlyPublic) {
        let url = flightUrl;

        if(onlyPublic){
            url += `?query={"isPublic":true}`;
        }

        return requester.get(url);
    };

    return {
        add,
        flights
    }
}();