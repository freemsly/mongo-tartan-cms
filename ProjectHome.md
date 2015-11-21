This is a .NET, MVC 3 and MongoDB CMS system.  As of this check in it is far from complete and needs quite a bit of refinement, but is a start for a simple MongoDB based CMS solution.

Quick Start:

1. Get MongoDB and get it running locally (http://www.mongodb.org)

2. Get some initial content by using NUnit (http://www.nunit.org/) to execute the test:
> Tartan.Tests.PageControllerTest.SetupData();

3. Open ASP.NET Configuration by selecting Tartan.Web in Solution Explorer then choosing:
> Project/ASP.NET Configuration.

4. Create a new User and put it in a new role called "Editor"

5. Hit F5 with Tartan.Web set as your Startup Project to bring it up in Cassini.