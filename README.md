# VideoArchiver
Graphical Interface for sequential re-encoding of several video files with FFMPEG to a specific location

## Story
For maximum quality I record and upload Youtube videos with high bitrates, so Youtube can render its different resolutions optimally. But this comes with a big drawback(literaly). Huge file sizes. Over the years several multi-terabyte hard drives were needed to store them. I could have written a script that compresses and archives them, but opening a script or scheduling a job can be quite tedious. So I decided to write this little program to help me out. At the moment it just calls a basic re-encode on selected video files sequentially. E.g. a 22 min 7.8gb ego-shooter video was reduced to 1.8gb and moved to another hard drive at the same time.


## How to
1. Select the installation path of your "ffmpeg.exe"
2. Select some video files
3. Select a target path
4. Press "Archive"
5. ...
6. Profit

## Any ideas?
If you'd like to have more features, improvements or better GUI redesign, let me know

## Possible ideas
* Showing more information about progess in the ui
* Hiding the FFMPEG commandline window
* FileSystemWatcher for automated encoding + archiving
* Webservice to receive calls via HTTP requests to start certain tasks
* Scheduler
