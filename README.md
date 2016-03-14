# Case 17613
Reproduction for support case 17613

##NServiceBus Version

* 5.2.0

##RavenDb Version

* 2.5.2956 (Customer version, 2.5.2996 was used for reproduction)

##Endpoint Configuration

* Json serialization
* Ravendb persistence
* Log4net
* MSMQ* 

## Notes

* [sagadata.json](sagadata.json) is how it appears in RavenDb studio.
* [PUT_TheSagaData.Fiddler2Dump.txt](PUT_TheSagaData.Fiddler2Dump.txt) is the Store call
* [GET_TheSagaData.Fiddler2Dump.txt](GET_TheSagaData.Fiddler2Dump.txt) is the Load call
* [Case17613.RavenDbTest/SerializeDecimalMinValueTest.cs](Case17613.RavenDbTest/SerializeDecimalMinValueTest.cs) contains a [failing RavenDB test](http://ravendb.net/docs/article-page/2.5/csharp/samples/raven-tests/createraventests).
