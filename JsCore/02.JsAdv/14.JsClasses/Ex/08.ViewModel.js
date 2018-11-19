class Textbox{
    constructor(selector, invalidSymbolsRegex){
        this.selector = selector;
        this._invalidSymbols = invalidSymbolsRegex;
        this._elements = $(this.selector);
        $(this.selector).on('input', function () {
            $('*[type=text]').val(this.value);
        });
    }

    isValid(){
        if(this.value.match(this._invalidSymbols)){
            return false;
        }
        return true;
    }
    get value(){
        return this.elements.val();
    }
    set value(val){
        this.elements.val(val);
    }

    get elements(){
        return this._elements;
    }
}