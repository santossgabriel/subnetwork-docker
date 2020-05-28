echo "1 - base"
echo "2 - dns"
echo "3 - employee"
echo "4 - ftp"
echo "5 - proxy"
echo "6 - threat"
echo "7 - webmail"

read OPTION
IMAGE=''

case $OPTION in
  1) IMAGE="base"
  ;;
  2) IMAGE="dns"
  ;;
  3) IMAGE="employee"
  ;;
  4) IMAGE="ftp"
  ;;
  5) IMAGE="proxy"
  ;;
  6) IMAGE="threat"
  ;;
  7) IMAGE="webmail"
  ;;
  *)
  echo "Invalid option."
  exit
  ;;
esac

docker images |grep "$IMAGE"
if [ $? = 0 ];
then
  echo "Removing image..."
  docker rmi $IMAGE"lab:1.0"
  if [ $? != 0 ];
  then
    echo "Image be using."
    exit 1
  fi
fi
docker build -t $IMAGE"lab:1.0" ./$IMAGE