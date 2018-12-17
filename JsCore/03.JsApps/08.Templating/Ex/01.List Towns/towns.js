function attachEvents(){
    $('#btnLoadTowns').on('click', parseInput);
    
    function parseInput() {
        let townsField = $('#towns');
        let currentTowns = townsField.val()
            .split(', ')
            .map(x => ({
                name: x.trim()
            })).filter(x => x.name !== '');

        loadTowns(currentTowns);

        townsField.val('');

        function loadTowns(towns){
            let source = $('#towns-template').html();
            let compiled = Handlebars.compile(source);

            let template = compiled({
                towns
            });

            $('#root').html(template);
        }
    }
}