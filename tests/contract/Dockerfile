# syntax=docker/dockerfile:1.2
FROM node:18.20.3

WORKDIR /src

COPY /tests/contract ./tests/contract
COPY /specs ./specs

WORKDIR /src/tests/contract

RUN npm install

ENV ENVIRONMENT_NAME=

HEALTHCHECK NONE

# Grant permissions for to our script to be executable and fix line endings
RUN tr -d '\015' < entrypoint.sh > ep2.sh && mv ep2.sh entrypoint.sh && chmod +x entrypoint.sh

ENTRYPOINT ["./entrypoint.sh"]