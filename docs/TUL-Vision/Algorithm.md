# Algorithm

## Divide to three, Python scripts
	1. FrameCapture
		a. Open stream
		b. Catch 1 frame every n=1 seconds
		c. Save frame in folder
			i. /data/raw_new/raw_<camID>_<timestamp>.jpg
	2. FrameAnalysis
		a. Open first photo from /data/raw_new/
		b. Load AboutCam json
		c. OpenCV:
			i. Count people
			ii. Draw rectangles on peoples
			iii. Prepare json EventCam
		d. Save:
			i. Save EventCam to /data/analyzedJson_new/analyzed_<camID>_<timestamp>.json
			ii. Save new picture with rectangles to /data/analyzedPhoto_new/analyzed_<camID>_<timestamp>.jpg
			iii. Move raw picture from /data/raw_new/raw_<camID>_<timestamp>.jpg to /data/raw_archive/raw_<camID>_<timestamp>.jpg
	3. FrameSend
		a. Open MongoDB connection
		b. Select database and collection
		c. Send all files from folders, and move them:
			i. /analyzedPhoto_new/ and next move to /analyzedPhoto_archive/
            ii. /analyzedJson_new/ and next move to /analyzedJson_archive/