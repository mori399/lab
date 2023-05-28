const express = require("express");
   
const app = express();
   
// создаем парсер для данных 
const urlencodedParser = express.urlencoded({extended: false});

let result = 0; 
  
app.get("/", function (request, response) {
    response.sendFile(__dirname + "/index.html");
});
app.post("/", urlencodedParser, function (request, response) {
    if(!request.body) return response.sendStatus(400);
    console.log(request.body);

    result += Number(request.body.question1);
    result += Number(request.body.question2);
    if(request.body.question32 == "1" && request.body.question33 == "1") result ++;
    result += Number(request.body.question4);
    result += Number(request.body.question5);
    result += Number(request.body.question6);
    result += Number(request.body.question7);
    if(request.body.question82 == "1" && request.body.question83 == "1") result ++;
    result += Number(request.body.question9);
    result += Number(request.body.question10);

    response.send(`Привет ${request.body.userName} из ${request.body.userGroup} --- твой результат  ${result} из 10`);
});
   
app.listen(3000, ()=>console.log("Сервер запущен..."));