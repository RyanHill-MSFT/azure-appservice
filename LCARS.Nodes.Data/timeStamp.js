const fs = require('fs');

const timeStamp = (req) => {
    var date = new Date();
    var currentTimeStamp = date.toUTCString();
    var content = `${currentTimeStamp} - ${req.protocol}//${req.headers.host}${req.originalUrl}\n`;
    fs.writeFileSync('./logs/datanode.log', content, { flag: 'a+' });
};

module.exports = timeStamp