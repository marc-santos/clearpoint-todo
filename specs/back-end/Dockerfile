FROM mcr.microsoft.com/dotnet/aspnet:8.0

RUN apt update && apt install unzip

WORKDIR /tmp
ADD https://github.com/RicoSuter/NSwag/releases/download/v14.0.1/NSwag.zip ./NSwag.zip
RUN unzip NSwag.zip

WORKDIR /tmp/output

WORKDIR /tmp
COPY ./webapi.openapi.nswag .
COPY ./webapi.openapi.yaml .

ENTRYPOINT ["dotnet", "./Net80/dotnet-nswag.dll", "run", "./webapi.openapi.nswag"]