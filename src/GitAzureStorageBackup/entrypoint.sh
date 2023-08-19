#!/bin/sh

#
# entrypoint.sh
#
#   Created: 2023-06-09-10:15:39
#   Modified: 2023-06-09-10:15:40
#
#   Author: David G. Moore, Jr. <david@dgmjr.io>
#
#   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
#      License: MIT (https://opensource.org/licenses/MIT)
#

git config --global user.email "$GIT_USEREMAIL"
git config --global user.name "$GIT_USERNAME"
git config --global user.token "$GIT_TOKEN"

git clone --recurse-submodules "$GIT_REPO" /repo
