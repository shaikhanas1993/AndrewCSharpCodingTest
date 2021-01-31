# AndrewCSharpCodingTest

Build using .Net 5

Use Below Commands For Migrations in PM:
Add-Migration AndrewCSharpCodingTest.Core.DatabaseContext;
update-database

Sample request:
{
  "paymentId": 0,
  "creditCardName": "4953089013607",
  "cardHolder": "A Z",
  "expirationDate": "2021-03-21",
  "amount": 23,
  "securityCode": "12"
}

//above request will provide client simulation will success and failure response. Trying same request multiple times will produce different results of success and failure
