FROM mcr.microsoft.com/dotnet/sdk:8.0

RUN apt-get update && apt-get install --no-install-recommends -y jq

WORKDIR /etc/app/src

ENV PATH="$PATH:/root/.dotnet/tools"
ENV NUGET_PACKAGES="/etc/app/nuget"

RUN dotnet tool install --global dotnet-ef

COPY . .
RUN dotnet ef migrations bundle --configuration release --project TodoList.Infrastructure --startup-project TodoList.Api --context TodoList.Infrastructure.Persistence.TodoListDbContext --self-contained -o ./TodoList.Infrastructure/efbundle

COPY ./run-bundle.sh ./TodoList.Infrastructure/run-bundle.sh

# Assign read-write-execute permissions to the user ower and 
# read-execute permissions to group owner and others.
RUN chmod 755 ./run-bundle.sh

WORKDIR /etc/app/src/TodoList.Infrastructure

ENTRYPOINT ["./run-bundle.sh"]