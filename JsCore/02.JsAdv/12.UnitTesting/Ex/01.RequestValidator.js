function validator(object){
    let validKeys = ["method", "uri", "version", "message"];
    let validMethods = ["GET", "POST", "DELETE", "CONNECT"];
    let uriPattern = /^[a-zA-Z0-9_.]+$/g;
    let validVersions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
    let nonValidMessageCh = /^[^<>\\&'"]*$/g;

    if(!validMethods.includes(object["method"])){
        throw Error("Invalid request header: Invalid Method");
    } else if(!object.hasOwnProperty("uri") || object["uri"] === "" || (!object["uri"].match(uriPattern) && object["uri"] !== '*')){
        throw Error("Invalid request header: Invalid URI");
    } else if(!validVersions.includes(object["version"])){
        throw Error("Invalid request header: Invalid Version");
    } else if(!object.hasOwnProperty("message") || (object["message"] !== null && !object["message"].match(nonValidMessageCh))){
        throw Error("Invalid request header: Invalid Message");
    }

    return object;
}