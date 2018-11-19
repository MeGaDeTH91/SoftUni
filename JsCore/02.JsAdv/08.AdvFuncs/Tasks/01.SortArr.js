function sorter(array, type){
    if(type === 'asc'){
        array = array.sort((a, b) =>
            +a - +b
        );
    } else if(type === 'desc'){
        array = array.sort((a, b) =>
             +b - +a
        );
    }
    return array;
}