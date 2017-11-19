mkdir TestsResults
#Run UnitTests
cd Tests/AcceptanceTests
# Restore dependencies
dotnet restore
dotnet build
# Run tests
dotnet test --test-adapter-path:. --logger:xunit
# copy result to root directory
cp -f TestResults/TestResults.xml ../../TestsResults/AcceptanceTests.xml