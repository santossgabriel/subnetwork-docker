import httpService from './httpService'

const networkSweeping = ipRange => httpService.post(`/nmap/network-sweeping/${ipRange}`)

const bannerGrabbing = (ipRange, portRange) => httpService.post(`/nmap/banner-grabbing/${ipRange}/${portRange}`)

export default {
  networkSweeping,
  bannerGrabbing
}