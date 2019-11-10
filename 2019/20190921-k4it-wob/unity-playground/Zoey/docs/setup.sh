# copy all gizmo images from unity project to docs folder
# because Docsify cannot include files outside the docs folder

abc="$(find ../Assets/_INTERNAL_/Gizmos/ -type f -not -name \*.meta)"

mkdir -p _images/unity

for element in ${abc[*]};
do
    cp $element _images/unity
done