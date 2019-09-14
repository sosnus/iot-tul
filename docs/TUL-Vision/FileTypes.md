# About files and folders
This temporary document can help to understand directories

## Data tree
data
├── aboutcam
│   ├── about_cam0.json
│   ├── about_cam1.json
│   └── about_cam2.json
├── analyzedJson_archive
│   └── analyzed_cam0_1568466804.json
├── analyzedJson_new
│   └── analyzed_cam0_1568467422.json
├── analyzedPhoto_archive
│   └── analyzed_cam0_1568466804.jpg
├── analyzedPhoto_new
│   └── analyzed_cam0_1568467422.jpg
├── raw_archive
│   └── raw_cam0_1568466804.jpg
└── raw_new
    └── raw_cam0_1568467422.jpg


## Folders descriptions

`data` - main folder with data
`data/aboutcam` - contains all cameras metadata (as json files)

`data/analyzedJson_archive` - contains json files just uploaded to online database
`data/analyzedJson_new` - contains json files which are ready to upload to DB

`data/analyzedPhoto_archive` - contains photos just uploaded to online database
`data/analyzedPhoto_new` - contains json photos which are ready to upload to DB

`data/raw_archive` - contains photos just already analyzed by OpenCV
`data/raw_new` - contains photos just waiting for analysis by OpenCV