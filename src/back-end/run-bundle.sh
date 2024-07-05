#!/bin/sh
set -e

if [ "$APPLY_MIGRATION" = "true" ]
    then
        CONNECTION_STR="${CONNECTION_STR}"
        echo "Starting Bundled Migration."
        ./efbundle --connection "${CONNECTION_STR}"
        echo "Completed Bundled Migration."
    else
        echo "Skipping Bundled Migration"
fi
