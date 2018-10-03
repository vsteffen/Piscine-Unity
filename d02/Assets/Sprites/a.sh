for f in *ight.anim ; do
	a=$(echo $f | sed 's/Right/Left/')
	cp $f $a
done   
