// file access
const fs = require('fs');
const util = require('util');
const readFileAsync = util.promisify(fs.readFile);

const ca = require('win-ca');

module.exports = async (context, req) => {
    context.log('JavaScript HTTP trigger function processed a request.' + context.invocationId);

    try {
        let certs = [];
        ca({
            format: ca.der2.pem,
            store: ['My'],
            ondata: crt => certs.push(crt)
        });
        context.log(certs);
        let data;
        data = await readFileAsync(process.env['WEBSITE_PRIVATE_CERTS_PATH'] + '\\FA18D76167184DC0A220F06269020EA26C95014E');
    } catch (err) {
        context.log.error('ERROR', err);
        throw err;
    }
    const name = (req.query.name || (req.body && req.body.name));
    const responseMessage = name
        ? "Hello, " + name + ". This HTTP triggered function executed successfully."
        : "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.";

    context.res = {
        // status: 200, /* Defaults to 200 */
        body: responseMessage
    };
}