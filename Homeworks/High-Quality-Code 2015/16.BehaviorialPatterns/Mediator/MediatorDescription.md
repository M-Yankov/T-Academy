﻿### Mediator

1. __Описание__

 Този патърн се използва за връзка между обектите без те да знаят един за друг. Нещо подобно
 на `middle man`. По този начин се повишава абстракцията, логиката за свързването се съдържа
 единнствено във медиатора.

2. __Структура__

 Може да се състрои се от два абстрактни класа които да комуникират помежду си, така че техните
 наследници да не разбират за тази връзка. (малко като няква сапунка стана ама ...) За повече
 детайли може да погледнете демото.

23. __Предимства__

 * създава се връзка едно към много
 * намалява coupling

1. __Недостатъци__

 Медиатора може да стане доста по обем при по-сложна логика, съответно трябва да бъде разделен
 на класове и интерфейси.

7231. __Диаграма__

 На диаграмата ясно се вижда че обектите(в случая летящите машиини) незнаят една за друга и
 кои се грижи да са кодринирани.

 ![alt-image](https://raw.githubusercontent.com/M-Yankov/T-Academy/master/Homeworks/High-Quality-Code%202015/16.BehaviorialPatterns/Mediator/MediatorScreenShot.png)

9. __[Демо](https://github.com/M-Yankov/T-Academy/tree/master/Homeworks/High-Quality-Code%202015/16.BehaviorialPatterns/Mediator)__

 В демото съм подготвил известния пример с самолетите и кулата, която осъществява комуникация
 между тях. Примера се състои от два абстрактни класа `AirCradtMachine` и `BaseMediator`,
 които са наследени съответно от `ControlCenter` и `Plane, Helicopter`. Тук, за разлика от
 демото от лекциите, самата връзка е скрита. `ControlCenter`(кулата) пази в себе си списък 
 от `AirCradtMachine`-s, те имат следните методи _излитане_, _предвижване_ и  _кацане_. 
 Важно е преди да излети машината да бъде регистрирана, за може да се направи връзката между
  `кулата` и базовия клас на летящите машини. Освен списък с машините _кулата_ пази и поле
 върху което тези машини са разположени. При *излитане* машината се добавя в списъка и се
 поставя на първото свободно място в полето ако има такова, при *кацане* се маха от списъка,
 а идва и ключовата връзка __[предвижването](https://github.com/M-Yankov/T-Academy/blob/master/Homeworks/High-Quality-Code%202015/16.BehaviorialPatterns/Mediator/ControlCenter.cs#L56), където кулата проверява всички останали летящи
 машини за техните координати и съответно предвижва машината или дава съобщение за грешка__ с
 цел предотвратяване на сблъсък.
