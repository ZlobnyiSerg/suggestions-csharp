API Подсказок DaData.ru для C# / .NET
====================

Описание
---------------

Библиотека `suggestions-csharp` — это обертка над [API подсказок](https://dadata.ru/api/suggest/) DaData.ru для C# и других .NET-языков.

![Подсказки](doc/api-suggest.png)

Установка
---------

### 1. Подключите библиотеку

Используйте NuGet-пакет "DaData.Client".

Внешние зависимости:

- [RestSharp](http://restsharp.org/)
- [NUnit](http://www.nunit.org/) (для тестов)


### 2. Получите API-ключи

Зарегистрируйтесь на [dadata.ru](https://dadata.ru) и получите API-ключи в [личном кабинете](https://dadata.ru/profile/#info).

### 3. Пользуйтесь API!

Примеры вызова API можно посмотреть в юнит-тестах (`SuggestClientTest`) или ниже по тексту.

Использование
---------

Работают подсказки по:

- почтовому адресу,
- реквизитам организации или банка,
- ФИО,
- адресу эл. почты.

```csharp
var token = "ВАШ API-КЛЮЧ";
// для бесплатных подсказок
var url = "https://dadata.ru/api/v2";
// для платных подсказок
// var url = "https://suggestions.dadata.ru/suggestions/api/4_1/rs"; 
var api = new SuggestClient(token, url);
var query = "москва серпухов";
var response = api.QueryAddress(query);
Console.WriteLine(string.Join("\n", response.suggestionss));
```
