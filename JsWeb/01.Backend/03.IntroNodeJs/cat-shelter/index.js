const http = require('http')
const port = 4000

http.createServer((req, res) => {
    res.writeHead(200, {
        'Content-Type' : 'text/plain'
    });

    res.write('Hello World!')
    res.end();
    
}).listen(port)