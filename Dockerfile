FROM microsoft/dotnet:2.2-sdk
COPY . /CarFinance247
WORKDIR /CarFinance247
RUN ["ls"]
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 5000/tcp

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh