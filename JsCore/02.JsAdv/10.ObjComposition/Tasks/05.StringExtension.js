(() => {
    String.prototype.ensureStart = function(str){
        if(!this.valueOf().startsWith(str)){
            return str + this.valueOf();
        }
        return this.toString();
    }

    String.prototype.ensureEnd = function(str){
        if(!this.valueOf().endsWith(str)){
            return this.valueOf() + str;
        }
        return this.valueOf();
    }

    String.prototype.isEmpty = function(){
        return this.valueOf() == "";
    }

    String.prototype.truncate = function(n){
        if(n < 4){
            return ".".repeat(n);
        } else if(this.valueOf().length <= n){
            return this.valueOf();
        } 
        let index = this.valueOf().substr(0, n - 2).lastIndexOf(" ");

        if(index < 0){
            return this.valueOf().substr(0, n - 3) + "...";
        } else{

            return this.valueOf().substr(0, index) + "...";
        }
    }
    String.format = function(string, ...params){
        for (let i = 0; i < params.length; i++) {
            const element = params[i];
            
            let index = string.indexOf(`{${i}}`);

            while(index >= 0){
                string = string.replace(`{${i}}`, element);

                index = string.indexOf(`{${i}}`);
            }
        }

        return string;
    }

})()
var str = 'the quick brown fox jumps over the lazy dog';
str = str.truncate(45)
console.log(str);