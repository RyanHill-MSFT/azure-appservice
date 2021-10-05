#!/usr/bin/env sh
set -e

echo "Starting ssh!"
/usr/sbin/sshd

exec "$@"