FROM microsoft/dotnet:2.0.3-sdk as builder
ARG source
WORKDIR /app
COPY . /app
RUN bash compile.sh
RUN /bin/bash "tests.sh"

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app/TestsResults ./TestsResults/
COPY --from=builder /app/Release .
EXPOSE 80
ENTRYPOINT ["dotnet", "Spider.Invoicing.API.dll"]