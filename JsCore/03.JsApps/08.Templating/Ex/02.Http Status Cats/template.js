$(() => {
    renderCatTemplate();

    async function renderCatTemplate() {
        let cats = window.cats;
        let source = await $.get('catTemplate.hbs');
        let compiled = Handlebars.compile(source);

        let template = compiled({
            cats
        });

        $('body').append(template);

        $('button').on('click', showInfo);

        function showInfo() {
            $(this).parent().children(':last-child').toggle();
            if($(this).text() === 'Show status code'){
                $(this).text('Hide status code');
            }else{
                $(this).text('Show status code');
            }
        }
    }

});