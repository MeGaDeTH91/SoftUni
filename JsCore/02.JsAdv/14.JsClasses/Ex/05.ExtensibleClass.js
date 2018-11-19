(function () {
    let id = 0;

    return class Extensible{
        constructor(){
            this.id = id++;
        }
        extend(template){
            for (const parentProperty of Object.keys(template)) {
                if(typeof(template[parentProperty]) == "function"){
                    Extensible.prototype[parentProperty] = template[parentProperty];
                } else{
                    this[parentProperty] = template[parentProperty];
                }
            }
        }
    };
})()
