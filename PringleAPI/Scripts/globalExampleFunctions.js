var JQXHR, RESPONSE;
function getBaseUrl() {
    let str = $(location).attr("href");
    let arr = str.trim().split("/");
    if (arr.length > 3)
        arr.splice(3, arr.length - 3);
    return arr.join("/");
}
function queryDone(jqxhr, status) {
    console.log(`status: ${status}`);
    JQXHR = jqxhr;
    RESPONSE = jqxhr.responseJSON;
}
function apicall(method, uriParams, bodyParams, callbacks) {
    //data: bodyParams,
    //url: `${getBaseUrl()}/api/customer?${uriParams}`,
    let args = {
        method: method,
        complete: queryDone
    }
    args.url = (typeof uriParams == "string" && uriParams.length > 0) ?
        `${getBaseUrl()}/api/customer?${uriParams}` :
        `${getBaseUrl()}/api/customer`;
    if (bodyParams != null && bodyParams != "") {
        args.data = bodyParams;
    }
    for (let i in callbacks) {
        args[i] = callbacks[i];
    }
    console.log(args);
    $.ajax(args);
}