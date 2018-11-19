function traverse(selector){
    let $target = $(selector).children();

    if($target.length === 0){
        $(selector).addClass('highlight');
    }
    let $next = $target;

    while($next.length){
        $target = $next;
        $next = $target.children();
    }
    $target.first().addClass('highlight');
    $target.first().parentsUntil($(selector).parent()).addClass('highlight');
}