 const home = (function(){
    const index = function(ctx) {
        let flightList;
        if(userModel.isAuthorized()){
            flightList = flightModel.flights(false);
        }else{
            flightList = flightModel.flights(true);
        }
        
        flightList.done(function (data) {
            ctx.flights = data;
            ctx.partial('views/home/index.hbs')
        });

    };

    return {
        index
    };
}());