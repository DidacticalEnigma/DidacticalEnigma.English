#!/bin/bash
npx autorest --csharp --input-file=swagger.json --namespace=DidacticalEnigma.English.LanguageTool --output-folder=. --public-clients
