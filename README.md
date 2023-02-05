# Project Title : "Access a RESTful resource and build a small database of quotes."

## Developer Details
* <b>Author : </b>Dhanush Kumar Komalapura Kumar

## Purpose of Project
This project involves accessing Restful API to query 10 quotes and write into a .txt file after rearranging 10 quotes from smallest to longest

## Dependencies
* The project is developed using Visual Studio 2019 with C# as the programming language.

## Prerequisites
* Project requires .NET 3.5 to .NET 5

## Installation steps
* Please click on <a herf = "https://visualstudio.microsoft.com/downloads/">Visual Studio</a> to download the specified version and follow the instructions on screen.

## Steps to Execute
* Unzip the Myproject_Assignment10.zip.net
* Unzip the app.zip and run the executable .exe file

## Steps to retrieve the source code
* Unzip the souce.zip
* Results in the main.cs file which contains the complete c# code.


## Explaination on methods Used for accessing Restful online
* Http Client Class is used for sending and receiving the response from URL "https://type.fit/api/quotes".
* Relevant NuGet package 'Newtonsoft.Json' was installed to extract and perform operations on JSON data from the http response from HTTP client.
* 'Newtonsoft.Json.Linq' namespace provides methods to work with JSON objects/ JSON response received from the HTTPClient
* 'HttpClient' allows for sending HTTP requests and receiving HTTP response from a resource URI
* 'HttpResponseMessage' used as a way of returning a message from the request.
* 'JArray' represents a JSON array to extract and store response from HTTP client.
* 'JObject' is an JSON array used to store string response from HTTP client.

* Dictionary collection us used for storing author/quote pairs. The dictionary is similar to non generic hash-table.
* Dictionary is dynamic, it's size grows according to our needs.

* Main is created as 'Async' class for aynchrous programming.

## Expected Output
* Text file with file name 'SortedQuotes.txt' will be generated and stored in D:\\ drive.


