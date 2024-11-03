#!/bin/bash

set -e

docker pull $IMAGE

docker stack deploy -c docker-swarm.yaml snackhubpaymentdev